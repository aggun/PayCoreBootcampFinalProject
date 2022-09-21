import React, { Component } from "react";
import UserService from "../services/user.service";
import { Redirect } from "react-router-dom";
import EventBus from "../common/EventBus";
import { Button } from "react-bootstrap";
import "./style.css";
import AuthService from "../services/auth.service";

export default class Categories extends Component {
  constructor(props) {
    super(props);

    this.state = ({
      redirect: null,
      content: [],
      error: ""

    });
  }

  componentDidMount() {
    UserService.getCategories().then(
      response => {
        this.setState({
          content: response.data
        });
      },
      error => {
        this.setState({
          content:
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString()
        });

        if (error.response && error.response.status === 401) {
          EventBus.dispatch("logout");
        }
      }

    );
    const currentUser = AuthService.getCurrentUser();

    if (!currentUser) this.setState({ redirect: "/Login" });
    this.setState({ currentUser: currentUser, userReady: true })

  }


  render() {

    if (this.state.redirect) {
      return <Redirect to={this.state.redirect} />
    }

    return (

      <div style={{ backgroundColor: "white" }} className="blaclist">

        <br /> <br />   <br /> <br />
        <div className="row product">

          <div className="col-md-6 product-detail">
            <h4>kategori Adı</h4>
         
          </div>

        </div>
        {this.state.content.map((item) => (
          <div className="row product">

            <div className="col-md-6 product-detail">
              <Button >{item.categoryName}</Button>

            </div>


          </div>
        ))}
      </div>
    );
  }
}


