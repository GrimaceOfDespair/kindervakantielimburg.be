<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="N2.Edit.Install._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Install N2</title>
    <link rel="stylesheet" type="text/css" href="../Resources/css/all.css" />
    <link rel="stylesheet" type="text/css" href="../Resources/css/framed.css" />
    <link rel="stylesheet" type="text/css" href="../Resources/css/themes/default.css" />
    <style>
    	form{font-size:1.1em;width:800px;margin:10px auto;}
    	a{color:#00e;}
    	li{margin-bottom:10px}
    	form{padding:20px}
    	.warning{color:#f00;}
    	.ok{color:#0c0;}
    	textarea{width:95%;height:120px; border:none; background-color:#FFB}
    	pre { overflow:auto; font-size:10px; color:Gray; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltStartupError" runat="server" />

        <n2:TabPanel ToolTip="1. Welcome" runat="server">
            <h1>Install N2 CMS</h1>
			<p class='<%# Status.IsInstalled ? "ok" : "warning" %>'>
				<b> Advice: </b> <%# GetStatusText() %>
            </p>
            <p>To install N2 you need to create a database, update the connection string in web.config, create the tables needed by N2, add the root node to the database and make sure the root node's id is configured in web.config.</p>
            <p>The following tabs will help you in these. Just continue to tab 2.</p>
            <h3>System status</h3>
            <p><%# Status.ToStatusString() %></p>
        </n2:TabPanel>
        
        <n2:TabPanel ToolTip="2. Database connection" runat="server">
            <h1>Check database connection</h1>
            <asp:Literal runat="server" Visible='<%# Status.IsConnected %>'>
				<p class="ok"><b>Advice: </b>Since your database seems connected you may skip this step.</p>
            </asp:Literal>
            <p>
                First make sure you have database available and <a href="http://n2cms.com/Documentation/Connection strings.aspx">configure connection string and database dialect</a> in web.config.
            </p>
            <p>Once you're done you can <asp:Button ID="btnTest" runat="server" OnClick="btnTest_Click" Text="test the connection" CausesValidation="false" /></p>
            <p>
                <asp:Label ID="lblStatus" runat="server" />
            </p>
        </n2:TabPanel>
        
        <n2:TabPanel ToolTip="3. Database tables" runat="server">
			<h1>Create datbase tables</h1>
            <asp:Literal runat="server" Visible='<%# Status.HasSchema %>'>
				<p class="ok"><b>Advice: </b>The database tables are okay. You can move to the next tab (if you create them again you will delete any existing content).</p>
            </asp:Literal>
            <asp:Literal runat="server" Visible='<%# !Status.IsConnected %>'>
				<p class="warning"><b>Advice: </b>Go back and check database connection.</p>
            </asp:Literal>
            <p>
				Please review the following SQL script carefully before creating tables using the buttons below.
            </p>
            <textarea readonly="readonly"><%= Installer.ExportSchema() %></textarea>
            <p>
				The script looks fine, please create tables in the database.
			</p>
			<p><asp:Button ID="btnInstall" runat="server" OnClick="btnInstall_Click" Text="Create tables" OnClientClick="return confirm('Creating database tables will destroy any existing data. Are you sure?');" ToolTip="Click this button to install database" CausesValidation="false"/></p>
			<hr />
			<p>
				Optionally I can 
				<asp:LinkButton ID="btnExport" runat="server" OnClick="btnExportSchema_Click" Text="download the SQL script" ToolTip="Click this button to generate create database schema script" CausesValidation="false" />
				for the connection type <strong><%= Status.ConnectionType %></strong> and create the tables myself.
            </p>
            <%--<p>
				You can also download sql scripts from 
                <a href="http://n2cms.com/Documentation/The database.aspx">the n2 cms home page</a> 
                (if you're using MySQL this is the preferred option).
			</p>--%>
            <p>
                <asp:Label CssClass="ok" runat="server" ID="lblInstall" />
            </p>
        </n2:TabPanel>
        
        <n2:TabPanel ToolTip="4. Content Package" runat="server">
			<h1>Install content package</h1>
            <asp:Literal runat="server" Visible='<%# Status.IsInstalled %>'>
				<p class="ok">
				    <b>Advice: </b>There is content present in the database. 
				    If you add more the old content remain but only one root can be used per site.
				</p>
            </asp:Literal>
            <asp:Literal runat="server" Visible='<%# !Status.HasSchema %>'>
				<p class="warning"><b>Advice: </b>Go back and check database connection and tables.</p>
            </asp:Literal>
            <asp:PlaceHolder ID="plhAddContent" runat="server">
                <p>
                    N2 CMS needs content in the database to function correctly.
                    The minum required is a <a href="http://n2cms.com/wiki/Root-node.aspx">root node</a> and a <a href="http://n2cms.com/wiki/Start-Page.aspx">start page</a>.
                </p>
                <div  style="display:<%= rblExports.Items.Count == 0 ? "none" : "block" %>">
                <p>
                    Pick the <b>content package</b> that tickle your fancy and import it into your site.
                </p>
                <div class="exports">
					<asp:RadioButtonList ID="rblExports" runat="server" RepeatLayout="Table" RepeatColumns="2" />
				</div>
			    <p>
			        <asp:Button ID="btnInsertExport" runat="server" OnClick="btnInsertExport_Click" Text="Please import this" ToolTip="Insert existing package" CausesValidation="false" />
			        <asp:CustomValidator ID="cvExisting" runat="server" ErrorMessage="Select an export file" Display="Dynamic" />
			    </p>
			    <script type="text/javascript">
			        function showadvancedcontentoptions() {
			            document.getElementById("advancedcontentoptions").style.display = "block";
			            this.style.display = "none";
			            return false;
			        }
			    </script>
			    <p><a href="#advancedcontentoptions" onclick="return showadvancedcontentoptions.call(this);">Advanced options (includes upload and manual insert).</a></p>
			    </div>
			    <div id="advancedcontentoptions" style="display:<%= rblExports.Items.Count > 0 ? "none" : "block" %>">
			        <h2>Upload and import package</h2>
			        <p>Select an export file you may have exported from another site and saved to disk to import on this installation.</p>
			        <p>Package: <asp:FileUpload ID="fileUpload" runat="server" />(*.n2.xml)</p>
			        <p>
			            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="upload and insert" ToolTip="Upload root node." CausesValidation="false" />
			            <asp:RequiredFieldValidator ID="rfvUpload" ControlToValidate="fileUpload" runat="server" Text="Select import file" Display="Dynamic" EnableClientScript="false" />
			        </p>
			        <h2>Manually insert nodes</h2>
			        <p>
			            Separate <asp:DropDownList ID="ddlRoot" runat="server" /> 
			            and <asp:DropDownList ID="ddlStartPage" runat="server" /> 
			            to <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="insert" ToolTip="Insert different root and start nodes" CausesValidation="false" /> 
			            as <b>two different</b> nodes (preferred)
			            <asp:CustomValidator ID="cvRootAndStart" runat="server" ErrorMessage="Root and start type required" Display="Dynamic" />
			        </p>
			        <p>
			            <b>Same node</b> for both <asp:DropDownList ID="ddlRootAndStart" runat="server" />
				        to <asp:Button ID="btnInsertRootOnly" runat="server" OnClick="btnInsertRootOnly_Click" Text="insert" ToolTip="Insert one node as root and start" CausesValidation="false" /> (simple site).
				        <asp:CustomValidator ID="cvRoot" runat="server" ErrorMessage="Root type required" Display="Dynamic" />
                    </p>
                </div>
            </asp:PlaceHolder>
			<p>
                <asp:Literal ID="ltRootNode" runat="server" />  
            </p>
<asp:PlaceHolder ID="phSame" runat="server" Visible="false">
            <h4>Example web.config with same root as start page</h4>
            <p>
                <textarea rows="4">
...
	<n2>
		<host rootID="<%# RootId %>" startPageID="<%# StartId %>"/>
		...
	</n2>
...</textarea>
				Please help me <asp:Button runat="server" OnClick="btnUpdateWebConfig_Click" Text="update web.config" CausesValidation="false" /> by writing these values to web.config (will cause app restart).
            </p>
</asp:PlaceHolder>
<asp:PlaceHolder ID="phDiffer" runat="server" Visible="false">
            <h4>Example web.config with different root as start pages</h4>
            <p>
                <textarea rows="4">
...
	<n2>
		<host rootID="<%# RootId %>" startPageID="<%# StartId %>"/>
		...
	</n2>
...</textarea>
				<asp:Button runat="server" OnClick="btnUpdateWebConfig_Click" Text="Update web.config" />
            </p>
</asp:PlaceHolder>
			<p><asp:Label runat="server" ID="lblWebConfigUpdated" /></p>
        </n2:TabPanel>
        
        <n2:TabPanel runat="server" tooltip="5. Finishing touches">
			<h1>Almost done!</h1>
            <p><b>IMPORTANT!</b> Change the default password in web.config. Once you've created a new administrator user using the management interface, comment out the credentials configuration section entirely.</p>
            <p><b>Advice:</b> remove the installation wizard located below /n2/installation/ to prevent nasty surprises.</p>
            <p>Please 
				<asp:Button runat="server" OnClick="btnRestart_Click" Text="restart" CausesValidation="false" />
				before you continue.
            </p>
            <p>Good luck and happy <a href="..">managing</a>!</p>
            <p>/Cristian</p>
        </n2:TabPanel>
        <pre><asp:Label EnableViewState="false" ID="errorLabel" runat="server" CssClass="errorLabel" /></pre>
    </form>
</body>
</html>
