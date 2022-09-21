import React, { Component } from "react";
import AuthService from "../services/auth.service";
import UserService from "../services/user.service";
import EventBus from "../common/EventBus";
import { Redirect } from "react-router-dom";
import { Table, Button } from "react-bootstrap";
import { Link } from "react-router-dom";

export default class ReceiveOffer extends Component {
  constructor(props) {
    super(props);

    this.state = {
      content: [],
      redirect: null
    };
  }

  componentDidMount() {
    UserService.viewReceiveOffer().then(
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

        <div>
          <br />
          <div>
            <h5>Teklifler</h5>
          </div>
          <Table striped >


            <thead>
              <tr>
                <th>   Ürün  </th>
                <th>  Fiyat     </th>
                <th>  Durum  </th>
                <th>  Onayla  </th>
              </tr>
            </thead>
            <tbody>

                  {this.state.content.map((item) => (

                <tr key={item.id}>

                  <th>  {item.productId}        </th>
                  <td>  {item.offerPrice}      </td>
                  <td>  {  (item.approval) ? "onaylandı" : "Reddedildi "    }       </td>
                  <td> <Button variant='warning'>   <Link to= {`${item.id}`}>Detay</Link> </Button></td>
                </tr>
          ))}   
            </tbody>
          </Table>
        </div>

      </div>
    );
  }
}
