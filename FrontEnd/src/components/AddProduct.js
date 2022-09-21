import React, { Component } from "react";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import CheckButton from "react-validation/build/button";
import userService from "../services/user.service";

const required = value => {
  if (!value) {
    return (
      <div className="alert alert-danger" role="alert">
        Lütfen bilgilerinizi giriniz.
      </div>
    );
  }
};

export default class AddProduct extends Component {
  constructor(props) {
    super(props);
    this.handleLogin = this.handleLogin.bind(this);
    this.onChangeProductName = this.onChangeProductName.bind(this);
    this.onChangeDescripton = this.onChangeDescripton.bind(this);
    this.onChangeCategoryId = this.onChangeCategoryId.bind(this);
    this.onChangeColor = this.onChangeColor.bind(this);
    this.onChangeBrand = this.onChangeBrand.bind(this);
    this.onChangePrice = this.onChangePrice.bind(this);


    this.state = {
      ProductName: "",
      Descripton:"",
      CategoryId: 0,
      Color: "",
      Brand: "",
      Price: 12.1,
      loading: false,
      message: ""
    };
  }

  
  onChangeProductName(e) {
    this.setState({
      ProductName: e.target.value
    });
  }


  onChangeDescripton(e) {
    this.setState({
      Descripton: e.target.value
    });
  }

  onChangeCategoryId(e) {
    this.setState({
      CategoryId: e.target.value
    });
  }

  onChangeColor(e) {
    this.setState({
      Color: e.target.value
    });
  }

  onChangeBrand(e) {
    this.setState({
      Brand: e.target.value
    });
  }

  onChangePrice(e) {
    this.setState({
      Price: e.target.value
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
      userService.AddProduct(this.state.ProductName, this.state.Descripton,this.state.CategoryId,
        this.state.Color,this.state.Brand,this.state.Price).then(
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
           <h3> Ürün Ekle</h3> 
           <br/> <br/>  
            <div className="form-group">
              <label htmlFor="ProductName"></label>
              <Input
                type="text"
                className="form-control"
                name="ProductName"
                placeholder="Ürün Adı"                                       
                value={this.state.ProductName}
                onChange={this.onChangeProductName}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="Descripton"></label>
              <Input
                type="text"
                className="form-control"
                name="Descripton"
                placeholder="açıklama"
                value={this.state.Descripton}
                onChange={this.onChangeDescripton}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="CategoryId"></label>
              <Input
                type="number"
                className="form-control"
                name="CategoryId"
                placeholder="Kategori No"
                value={this.state.CategoryId}
                onChange={this.onChangeCategoryId}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="Color"></label>
              <Input
                type="text"
                className="form-control"
                name="Color"
                placeholder="Renk"
                value={this.state.Color}
                onChange={this.onChangeColor}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="Brand"></label>
              <Input
                type="text"
                className="form-control"
                name="Brand"
                placeholder="Marka"
                value={this.state.Brand}
                onChange={this.onChangeBrand}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor=" Price"></label>
              <Input
                type="number"
                className="form-control"
                name=" Price"
                placeholder="Fiyat"
                value={this.state. Price}
                onChange={this.onChangePrice}
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
