<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monitoring.aspx.cs" Inherits="WebForm.Monitoring" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">

        body {
            padding: 0;
            margin: 0 0 0 0;
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
            margin: 0;
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
        #Button2 {
          background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px; cursor: pointer; margin-left: 1020px;
        }

        #Button2:hover {
            background-color: green;
        }
         .auto-style2 {
             position: absolute;
             left: 928px;
             top: 306px;
             width: 161px;
         }
         .auto-style3 {
             position: absolute;
             left: 929px;
             top: 361px;
             width: 157px;
         }
         .auto-style4 {
             position: absolute;
             left: 929px;
             top: 333px;
             width: 169px;
             height: 22px;
         }
         .auto-style5 {
             position: absolute;
             top: 207px;
             left: 669px;
             z-index: 1;
         }
         .auto-style6 {
             position: absolute;
             top: 289px;
             left: 425px;
             z-index: 1;
         }
         .auto-style7 {
             position: absolute;
             top: 200Px;
             left: 23px;
             z-index: 1;
         }

         #Label1, #mostPopularCity, #Label3 {
             background-color: lightgreen;
             padding: 5px;
             border-radius: 7px;
         }
    </style>
</head>
<body bgcolor="#c6dcff">
    <form id="form2" runat="server">
                    <div id="header" style="height: 64px">
            <h1 style="text-align:center" id="headerTitle">POLYVELIB&#39;S</h1>
        </div>
        <div id="header" style="height: 64px">
            <h3 style="text-align:center" id="headerTitle">MONITORING</h3>
        </div>
                    <p>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Recherche.aspx">Recherche</asp:HyperLink>
                    </p>
                    <p>
                        &nbsp;</p>
                    <div style="margin-left: 80px">
                        Nombre de recherches :&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Recherches"></asp:Label>


                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ville la plus recherchée&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Temps de réponse moyen :
                    <asp:Label ID="Label3" runat="server" Text="Temps"></asp:Label>


                        &nbsp;<asp:Label ID="mostPopularCity" runat="server" Text="Villes" CssClass="auto-style5"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    

                    <asp:Chart ID="Chart1" runat="server" Width="500px" style="margin-left: 0px" CssClass="auto-style6">
                        <series>
                            <asp:Series Name="Series0">
                            </asp:Series>
                            <asp:Series Name="Series1">
                            </asp:Series>
                            <asp:Series Name="Series2">
                            </asp:Series>
                            <asp:Series Name="Series3">
                            </asp:Series>
                            <asp:Series Name="Series4">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>


                    <asp:Label ID="Label4" runat="server" Text="Label" CssClass="auto-style2" ></asp:Label>


                    <div style="margin-left: 80px">
&nbsp;</div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="Label" CssClass="auto-style3"></asp:Label>


                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 1316px" Text="Mettre à jour" Width="163px" CssClass="auto-style7" />


                    <p>
                    <asp:Label ID="Label5" runat="server" Text="Label" CssClass="auto-style4"></asp:Label>
                    </p>


    </form>
    </body>
</html>