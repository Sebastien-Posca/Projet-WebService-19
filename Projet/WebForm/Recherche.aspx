<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Recherche.aspx.cs" Inherits="WebForm.Recherche" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        body {
            padding: 0;
            margin: -30px 0 0 0;
        }

        a { background-color: red; font-size:10px; box-shadow: 0 3px 0 darkred; color: white; margin-left:3em; padding: 1em 1.5em; position: relative; text-decoration: none; text-transform: uppercase; } a:hover { background-color: #ce0606; cursor: pointer; } a:active { box-shadow: none; top: 5px; }

        /** FORM **/

        body, #form1 {
            background-color: rgb(185, 225, 243)
        }

        /** HEADER **/

        #header {
            background-color: rgb(45, 47, 113);
        }

        #headerTitle {
            padding-top: 20px;
            color: white;
        }

        /** SEARCH **/

        #searchFields {
            margin-left: 200px;
        }
        
        .search-field {
          width: 150px;
          padding: 10px 10px;
          margin: 20px 0;
          display: inline-block;
          border: 1px solid #ccc;
          border-radius: 4px;
          box-sizing: border-box;
        }


        /*#city, #stationNumber, #stationName {
            padding: 5px;
            border: none;
            border-radius: 5px;
            font-size: 13px;
        }*/

        #search  {
              background-color: #4CAF50;
              border: none;
              color: white;
              text-align: center;
              text-decoration: none;
              display: inline-block;
              font-size: 16px;
              cursor: pointer;
              padding: 10px 10px;
              margin: 20px 0;
            }
 

        #search:hover {
            background-color: green;
            padding: 10px 10px;
        }

        .follow {
            display: inline-block;
        }

        /** LISTE **/

        #info {
            margin: 0;
            font-size: 16px;
        }

        #List {
            width: 100%;
            border:none;
        }

        select {
            border-radius: 5px;
        }

        select > option {
            margin: 5px;
            padding: 3px;
            box-shadow: rgb(178, 178, 178) -1px -1px;
        }

        select > option:hover {
            background-color: lightblue;
            cursor: pointer;
        }
    </style>
</head>
<body bgcolor="#c6dcff">
    <form id="form1" runat="server">
        <div id="header" style="height: 64px">
            <h1 style="text-align:center" id="headerTitle">POLYVELIB&#39;S</h1>
        </div>
        <p>
            <a href="Monitoring.aspx">Monitoring</a></p>
            <p>&nbsp;</p>
        <div id="searchFields">
            <asp:Textbox  class="search-field" runat="server" id="city" placeholder="Ville" type="text" />
            <asp:Textbox  class="search-field" runat="server" id="stationNumber" placeholder="Numero" type="text" OnTextChanged="stationNumber_TextChanged" />
            <asp:Textbox  class="search-field" runat="server" id="stationName" placeholder="Nom" type="text" />
            <asp:Button ID="search" runat="server" style="margin-left: 52px" Text="Rechercher" OnClick="SearchAsync" />
            <p class="follow"> &nbsp; <asp:Label ID="info" runat="server" Text=" "></asp:Label> </p>
        </div>
        <div style="margin-left: 200px; margin-right: 200px">
            <asp:ListBox ID="List" runat="server" OnSelectedIndexChanged="List_SelectedIndexChangedAsync" AutoPostBack="true"> </asp:ListBox>
            <br />
            <p> &nbsp;</p>
        </div>
    </form>
    <p>
        &lt;</p>
    </body>
</html>
