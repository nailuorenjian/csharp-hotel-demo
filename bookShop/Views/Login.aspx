<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="bookShop.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>
        body{
            background-image: url("https://wallpapercave.com/wp/wp2552690.jpg");
            background-size: cover;
        }
        .container-fluid{
            display: flex;
            align-items: center;
            justify-content: center;
             height: 100vh;
        }
        .form-floating{
             width: 70%;
        }
    </style>
    <title>Login</title>
</head>
<body>
    <div class="container-fluid">
       <form id="form1" runat="server">
        <h1 class="col-md-4">Please sign in</h1>

    <div class="form-floating">
      <input type="text" class="form-control" runat="server" id="UnameTb" placeholder="UserName" />
      <label for="floatingInput">user name</label>
    </div>

    <div class="form-floating">
      <input type="password" class="form-control" runat="server" id="PasswordTb" placeholder="Password" />
      <label for="floatingPassword">Password</label>
    </div>

      <div class="form-floating">
          <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger"></asp:Label>
          <asp:Button Text="sign in" runat="server" class="btn-success btn" ID="LoginBtn" OnClick="LoginBtn_Click1" />
      </div>

        </form>
    </div>
  
</body>
</html>
