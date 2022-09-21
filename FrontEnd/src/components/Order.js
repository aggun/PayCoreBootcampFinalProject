import React, { Component } from "react";
import UserService from "../services/user.service";
import { Redirect } from "react-router-dom";
import EventBus from "../common/EventBus";
import "./style.css";
import AuthService from "../services/auth.service";

export default class Order extends Component {
  constructor(props) {
    super(props);

    this.state = ({
      redirect: null,
      content: [],
      error: ""

    });
  }

  componentDidMount() {
    UserService.viewOrder().then(
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
            <h4>Ürün Adı</h4>
            <p>Açıklama</p>
          </div>
          <div className="col-md-2 product-price">
            Fiyat
          </div>
        </div>
        {this.state.content.map((item) => (
          <div className="row product">

            <div className="col-md-6 product-detail">
              <h4>{item.productName}</h4>

            </div>
            <div className="col-md-2 product-price">
              {item.price}
            </div>

          </div>
        ))}
      </div>
    );
  }
}


