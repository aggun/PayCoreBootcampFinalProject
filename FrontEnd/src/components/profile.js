import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import AuthService from "../services/auth.service";



export default class Profile extends Component {
  constructor(props) {
    super(props);

    this.state = {
      redirect: null,
      userReady: false,
      content: [],
      statusCode: "",
      err: "",
      currentUser: { username: "" }
    };
  }

  componentDidMount() {
    const currentUser = AuthService.getCurrentUser();

    if (!currentUser) this.setState({ redirect: "/Login" });
    this.setState({ currentUser: currentUser, userReady: true })

  //  UserService.getDetails().then(
    //  response => {
     //   this.setState({
     //     statusCode: response.status,
      //    content: response.data

     //   });

    //  },
    //  error => {
    //    this.setState({
     //     content:
      //      (error.response && error.response.data && error.response.status) ||
      //      error.message ||
      //      error.toString(),
    //      err: error,

   //     });
   //   }
   // );

  }

  render() {
    if (this.state.redirect) {
      return <Redirect to={this.state.redirect} />
    }

    const { currentUser } = this.state;



    return (


      <div style={{ backgroundColor: "white" }}>

        <br /> <br />
        <div className="container"  >
          {(this.state.userReady) ?
            <div className="jumbotron" style={{ backgroundColor: "white" }}>
              <header className="jumbotron" style={{ backgroundColor: "white" }}>
                <h3>
                  <strong>{currentUser.name}</strong> Welcome
                </h3>
              </header>

              <p>
                <strong>Oturum Süresi:</strong>{" "}
                {currentUser.sessionTimeInSecond / 60} dakika oturum süresi
              </p>
              <p>
                <strong>Kullanıcı ID:</strong>{" "}
                {currentUser.email}
              </p>

            </div> : null}
        </div>
        <div style={{ backgroundColor:"#f2f7ff"}}>
        <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
          </div>

      </div>
    );
  }
}
