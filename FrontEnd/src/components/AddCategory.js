import React, { Component } from "react";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import CheckButton from "react-validation/build/button";
import userService from "../services/user.service";

const required = value => {
  if (!value) {
    return (
      <div className="alert alert-danger" role="alert">
        Lütfen bilgileri giriniz.
      </div>
    );
  }
};

export default class AddCategory extends Component {
  constructor(props) {
    super(props);
    this.handleLogin = this.handleLogin.bind(this);
    this.onChangeCategoryName = this.onChangeCategoryName.bind(this);

    this.state = {
      CategoryName: "",
      loading: false,
      message: ""
    };
  }

  



  onChangeCategoryName(e) {
    this.setState({
      CategoryName: e.target.value
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
      userService.AddCategory(this.state.CategoryName).then(
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

          <Form
            onSubmit={this.handleLogin}
            ref={c => {
              this.form = c;
            }}
          >
            <br/> <br/>  <br/> <br/> 
           <h3> Kategori Ekle</h3> 
           <br/> <br/>  

            <div className="form-group">
              <label htmlFor="CategoryName"></label>
              <Input
                type="text"
                className="form-control"
                name="CategoryName"
                placeholder="Kategori Adı"
                value={this.state.CategoryName}
                onChange={this.onChangeCategoryName}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <button
                className="btn btn-primary btn-block"
                disabled={this.state.loading}type="submit"
              >
                {this.state.loading && (
                  <span className="spinner-border spinner-border-sm"></span>
                )}
                <span>Kategori Ekle</span>
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
