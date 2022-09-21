import React, { Component } from "react";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import CheckButton from "react-validation/build/button";

import AuthService from "../services/auth.service";

const required = value => {
  if (!value) {
    return (
      <div className="alert alert-danger" role="alert">
        Lütfen bilgilerinizi giriniz.
      </div>
    );
  }
};

export default class Register extends Component {
  constructor(props) {
    super(props);
    this.handleLogin = this.handleLogin.bind(this);
    this.onChangeEmail = this.onChangeEmail.bind(this);
    this.onChangeName = this.onChangeName.bind(this);
    this.onChangePassword = this.onChangePassword.bind(this);

    this.state = {
      Email: "",
      Name:"",
      Password: "",
      loading: false,
      message: ""
    };
  }



  onChangeEmail(e) {
    this.setState({
      Email: e.target.value
    });
  }

  onChangePassword(e) {
    this.setState({
      Password: e.target.value
    });
  }

  onChangeName(e) {
    this.setState({
      Name: e.target.value
    });
  }

  handleLogin(e) {
    e.preventDefault();

    this.setState({
      message: "",
      loading: true
    });

    this.form.validateAll();

    if (this.checkBtn.context._errors.length === 0) {
      AuthService.Register(this.state.Email, this.state.Name,this.state.Password).then(
        () => {
          this.props.history.push("/profile");
          window.location.reload();
        },
        error => {
          const resMessage =
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString();

          this.setState({
            loading: false,
            message: resMessage
          });
        }
      );
    } else {
      this.setState({
        loading: false
      });
    }
  }

  render() {
    return (
    
        <div className="login" >
          <img
            src="https://cdn1.ntv.com.tr/gorsel/R8-F3T9BmE2BQhh_67kn8Q.jpg?width=588&mode=crop&scale=both"
            alt="profile-img"
          className="imgl"
          />

          <Form
            onSubmit={this.handleLogin}
            ref={c => {
              this.form = c;
            }}
          >
            <br/> <br/>  <br/> <br/> 
           <h3> Üye Ol</h3> 
           <br/> <br/>  
            <div className="form-group">
              <label htmlFor="Email"></label>
              <Input
                type="text"
                className="form-control"
                name="Email"
                placeholder="Kullanıcı Adı"
                value={this.state.Email}
                onChange={this.onChangeEmail}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="Name"></label>
              <Input
                type="text"
                className="form-control"
                name="Name"
                placeholder="Ad Soyad"
                value={this.state.Name}
                onChange={this.onChangeName}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="Password"></label>
              <Input
                type="Password"
                className="form-control"
                name="Password"
                placeholder="Şifre"
                value={this.state.Password}
                onChange={this.onChangePassword}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <button
                className="btn btn-primary btn-block"
                disabled={this.state.loading}
              >
                {this.state.loading && (
                  <span className="spinner-border spinner-border-sm"></span>
                )}
                <span>Login</span>
              </button>
        
            </div>
           
            {this.state.message && (
              <div className="form-group">
                <div className="alert alert-danger" role="alert">
                  {this.state.message}
                </div>
              </div>
            )}
                   <CheckButton
              style={{ display: "none" }}
              ref={c => {
                this.checkBtn = c;
              }}
            />
          </Form>
    
        </div>
        
      
    );
  }
}
