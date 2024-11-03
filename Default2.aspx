<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Practical File PDF Generator</title>
    <style>
        .form-container {
            max-width: 400px;
            margin: auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-group input {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .btn-submit {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
        }
        .btn-submit:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="form-group">
                <label for="txtUniversity">University Name</label>
                <asp:TextBox ID="txtUniversity" runat="server" Placeholder="Enter University Name"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDepartment">Department</label>
                <asp:TextBox ID="txtDepartment" runat="server" Placeholder="Enter Department"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSubject">Subject</label>
                <asp:TextBox ID="txtSubject" runat="server" Placeholder="Enter Subject"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSubmittedTo">Submitted To</label>
                <asp:TextBox ID="txtSubmittedTo" runat="server" Placeholder="Enter "></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSubmittedBy">Submitted By</label>
                <asp:TextBox ID="txtSubmittedBy" runat="server" Placeholder="Enter your name"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtRollNo">Roll NO</label>
                <asp:TextBox ID="txtRollNo" runat="server" Placeholder="Enter Roll No"></asp:TextBox>
            </div>
            <asp:Button ID="btnGeneratePDF" runat="server" CssClass="btn-submit" Text="Generate PDF" OnClick="btnGeneratePDF_Click" />
        </div>
    </form>
</body>
</html>
