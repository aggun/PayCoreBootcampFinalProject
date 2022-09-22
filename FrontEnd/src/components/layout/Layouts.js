import React, { Component } from "react";
import { Switch, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import { Navbar } from "react-bootstrap";
import "./sty.css";
import { VscSearch, VscOutput, VscChecklist } from "react-icons/vsc";
import { AiOutlineLogin } from "react-icons/ai";
import AuthService from "../../services/auth.service";
import Login from "../login";
import Profile from "../profile";
import MySendOffer from "../MySendOffer";
import Products from "../Products"
import AddProduct from "../AddProduct"
import Register from "../Register"
import ReceiveOffer from "../ReceiveOffer";
import NotFoundError from "./NotFoundError";
import EventBus from "../../common/EventBus";
import Order from "../Order";
import AddCategory from "../AddCategory";
import Categories from "../Categories"


export default class layouts extends Component {
  constructor(props) {
    super(props);
    this.logOut = this.logOut.bind(this);

    this.state = {
      showModeratorBoard: false,
      showAdminBoard: false,
      currentUser: undefined,
      layout: false,
      ly: true,
      redirect: null,
      content: [],
      error: ""
    };
  }


  componentDidMount() {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user != null) {
      this.setState({
        currentUser: user,
        showModeratorBoard: true,
        showAdminBoard: true,
        layout: true,
      });
    }

    EventBus.on("logout", () => {
      this.logOut();
    });

    const currentUser = AuthService.getCurrentUser();

    if (!currentUser) this.setState({ redirect: "/Login" });
    this.setState({ currentUser: currentUser, userReady: true })

  }

  componentWillUnmount() {
    EventBus.remove("logout");
  }

  logOut() {
    AuthService.logout();
    this.setState({
      showModeratorBoard: false,
      showAdminBoard: false,
      currentUser: undefined,
      layout: false,
    });
  }


  render() {
    const { currentUser, showModeratorBoard } = this.state;

    return (
      <div className="anadiv" >

        <div className="anadiv" >


          <div className="anadiv" >

            <div className="anadiv" >

              <Navbar variant="dark" className="sbt " >

                {currentUser ? (
                  <div className="navbar-nav ml-auto" >

                    <li className="nav-item">
                      <Link to={"/profile"} className="nav-link">
                        {currentUser.username}
                      </Link>
                    </li>

                    <li className="nav-item">
                      <a href="/login" className="nav-link" onClick={this.logOut} style={{ color: "black", fontSize: 20 }}>
                        <   AiOutlineLogin />         LogOut
                      </a>
                    </li>


                  </div>
                ) : (
                  <div className="navbar-nav ml-auto">

                    <li className="nav-item">
                      <Link to={"/Login"} className="nav-link" style={{ color: "black", fontSize: 20 }}>
                        Login
                      </Link>
                    </li>

                    <li className="nav-item">
                      <Link to={"/Register"} className="nav-link" style={{ color: "black", fontSize: 20 }}>
                        Register
                      </Link>
                    </li>
                  </div>
                )}
              </Navbar>
            </div>


            <div className="cont" >


              <Switch>
                <Route exact path="/Login" component={Login} />
                <Route exact path="/Register" component={Register} />
                <Route exact path="/Profile" component={Profile} />
                <Route path="/ReceiveOffer" component={ReceiveOffer} />
                <Route path="/AddProduct" component={AddProduct} />
                <Route path="/Offers" component={MySendOffer} />
                <Route path="/Categories" component={Categories} />
                <Route path="/Products" component={Products} />
                <Route path="/AddCategory" component={AddCategory} />
                <Route path="/Orders" component={Order} />
                <Route path="*" component={NotFoundError} />
              </Switch>

            </div>
            {currentUser ? (
              <div className="side" >
                <Navbar >
                  <div >

                    <Link to={"/Profile"} className="navbar-brand">
                      <img src="https://cdn1.ntv.com.tr/gorsel/R8-F3T9BmE2BQhh_67kn8Q.jpg?width=588&mode=crop&scale=both"></img>
                    </Link>
                    <br /> <br /> <br /> <h4 align="center">Ana Menü</h4> <br /> <br />
                    <ul>


                      <li >

                        <Link to={"/Products"} className="nav-link" style={{ color: "black", fontSize: 18, left: 0 }}>
                          <VscSearch />       Ürünler
                        </Link>
                      </li>


                      <br />


                      <li className="list">
                        <Link to={"/Categories"} className="nav-link" style={{ color: "black", fontSize: 18 }}>
                          <   VscOutput />      Kategoriler
                        </Link>
                      </li>


                      <br />


                      <li className="list">
                        <Link to={"/Orders"} className="nav-link" style={{ color: "black", fontSize: 18 }}>
                          <   VscChecklist />      Siparişlerim
                        </Link>
                      </li>

                      <br />


                      <li className="list">
                        <Link to={"/Offers"} className="nav-link" style={{ color: "black", fontSize: 18 }}>
                          <   VscChecklist />      Tekliflerim
                        </Link>
                      </li>

                      <br />


                      <li className="list">
                        <Link to={"/ReceiveOffer"} className="nav-link" style={{ color: "black", fontSize: 18 }}>
                          <   VscChecklist />      Gelen Teklifler
                        </Link>
                      </li>

                      <br />




                      <li className="list">
                        <Link to={"/AddCategory"} className="nav-link" style={{ color: "black", fontSize: 18 }}>
                          <   VscChecklist />      Kategori Ekle
                        </Link>
                      </li>

                      <br />


                      <li className="list">
                        <Link to={"/AddProduct"} className="nav-link" style={{ color: "black", fontSize: 18 }}>
                          <   VscChecklist />      Ürün Ekle
                        </Link>
                      </li>

                    </ul>
                  </div>
                </Navbar>
              </div>
            ) : (
              <div></div>
            )


            }

          </div>
        </div>

      </div>
    );

  }
}

