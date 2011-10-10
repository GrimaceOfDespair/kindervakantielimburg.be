using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using N2;
using N2.Details;
using N2.Web;

namespace KVG.Core.Attributes
{
    public abstract class ContentItemSelectorAttribute : AbstractEditableAttribute
    {
        public ContentItemSelectorAttribute(string title, int sortOrder)
            : base(title, sortOrder)
        {
            AllowEmptySelection = true;
            AllowNonExistingSelection = true;
        }

        public bool AllowEmptySelection { get; set; }
        public bool AllowNonExistingSelection { get; set; }

        protected virtual ListControl CreateListControl()
        {
            return new DropDownList();
        }

        protected virtual ContentItem GetContentItemByValue(string selectedValue)
        {
            return Engine.Resolve<IUrlParser>().Parse(selectedValue);
        }

        protected virtual string GetContentItemValue(ContentItem contentItem)
        {
            return contentItem.Url;
        }

        protected virtual string GetContentItemName(ContentItem contentItem)
        {
            return contentItem.Title;
        }

        protected virtual ListItem CreateContentItemListItem(ContentItem contentItem)
        {
            return new ListItem(
                GetContentItemName(contentItem),
                GetContentItemValue(contentItem));
        }

        protected virtual IEnumerable<ListItem> GetListItems(Control container)
        {
            if (AllowEmptySelection)
            {
                yield return new ListItem(GetLocalizedText("Empty"), "");
            }

            foreach (var contentItem in GetContentItems())
            {
                yield return CreateContentItemListItem(contentItem);
            }
        }

        public abstract IEnumerable<ContentItem> GetContentItems();

        private static void MakeSureItemIsInList(ListControl listControl, ContentItem item)
        {
            var listItem = listControl.Items.FindByValue(item.Url);
            if (listItem == null)
            {
                listControl.Items.Add(
                    new ListItem(item.Title, item.Url) {Selected = true});
            }
            else
            {
                listItem.Selected = true;
            }
        }

        public override bool UpdateItem(ContentItem item, Control editor)
        {
            var listControl = (ListControl)editor;
            var valueItem = item[Name] as ContentItem;
            var url = valueItem != null ? valueItem.Url : "";
            if (listControl.SelectedValue != url)
            {
                item[Name] = GetContentItemByValue(listControl.SelectedValue);
                return true;
            }
            return false;
        }

        public override void UpdateEditor(ContentItem item, Control editor)
        {
            var listControl = (ListControl)editor;
            var propertyValue = item[Name] as ContentItem;
            if (propertyValue == null)
            {
                if (AllowEmptySelection) listControl.SelectedValue = "";
            }
            else if (AllowNonExistingSelection)
            {
                MakeSureItemIsInList(listControl, propertyValue);
            }
        }

        protected override Control AddEditor(Control container)
        {
            var listControl = CreateListControl();
            foreach (var li in GetListItems(container))
            {
                listControl.Items.Add(li);
            }
            container.Controls.Add(listControl);
            return listControl;
        }
    }
}
