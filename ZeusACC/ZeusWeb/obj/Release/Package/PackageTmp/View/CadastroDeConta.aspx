<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDeConta.aspx.cs" Inherits="ZeusWeb.View.CadastroDeConta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="server">
    
        <div class="right_col" role="main">
          <div class="">
            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Cadastro de Conta <small>cadastre as contas dos jogadores!</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      </li>
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                        <ul class="dropdown-menu" role="menu">
                          <li><a href="#">Settings 1</a>
                          </li>
                          <li><a href="#">Settings 2</a>
                          </li>
                        </ul>
                      </li>
                      <li><a class="close-link"><i class="fa fa-close"></i></a>
                      </li>
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">

                    <form class="form-horizontal form-label-left" novalidate>

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Nome <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="txtNome" class="form-control col-md-7 col-xs-12" data-validate-length-range="4" data-validate-words="1" name="name" placeholder="Informe o nome da conta, ex: muniz" required="required" type="text">
                        </div>
                      </div>

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Email <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="email" id="txtEmail" name="email" required="required" class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">Confirmar Email <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="email" id="txtEmail2" name="confirm_email" data-validate-linked="email" required="required" class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="number">Dias de premium <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="number" id="txtDiasPremium" name="number" required="required" data-validate-minmax="1" class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>

                      <div class="item form-group">
                        <label for="password" class="control-label col-md-3">Senha</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="txtSenha" type="password" name="password" data-validate-length="6,8" class="form-control col-md-7 col-xs-12" required="required">
                        </div>
                      </div>

                      <div class="item form-group">
                        <label for="password2" class="control-label col-md-3 col-sm-3 col-xs-12">Repetir Password</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="txtSenha2" type="password" name="password2" data-validate-linked="password" class="form-control col-md-7 col-xs-12" required="required">
                        </div>
                      </div>

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="telephone">Grupo de segurança <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="tel" id="txtGrupoSeguranca" name="phone" required="required" data-validate-length-range="8,20" class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>

                      <div class="item form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="textarea">Observação <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <textarea id="txtObservacao" required="required" name="textarea" class="form-control col-md-7 col-xs-12"></textarea>
                        </div>
                      </div>

                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-6 col-md-offset-3">
                          <button type="submit" class="btn btn-primary">Cancelar</button>
                          <button id="send" type="submit" class="btn btn-success">Cadastrar</button>
                        </div>
                      </div>

                        <div class="panel-body">
                            <h3 class="text-center" id="divMsgSucesso" CssClass="hidden" runat="server"></h3>
                        </div>

                    </form>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">

    <!-- jQuery -->
    <script src="../Assets/Plugins/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../Assets/Plugins/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../Assets/Plugins/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../Assets/Plugins/nprogress/nprogress.js"></script>
    <!-- validator -->
    <script src="../Assets/Plugins/validator/validator.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>

    <script src="js/CadastroDeConta.js"></script>

</asp:Content>

