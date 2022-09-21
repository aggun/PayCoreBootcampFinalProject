import React, { Component } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import AuthService from "./services/auth.service";
import EventBus from "./common/EventBus";
import Layouts from "./components/layout/Layouts";

class App extends Component {
  constructor(props) {
    super(props);
    this.logOut = this.logOut.bind(this);

    this.state = {
      layout: false,
      ly: true
    };
  }

  componentDidMount() {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user != null) {
      this.setState({
        layout: true,
        ly: false
      });
    }

    EventBus.on("logout", () => {
      this.logOut();
    });
  }

  componentWillUnmount() {
    EventBus.remove("logout");
  }

  logOut() {
    AuthService.logout();
    this.setState({
      layout: false,
      ly: true
    });
  }


  render() {
   
        return (
          <div  >
            <Layouts></Layouts>               
          </div>
        );
}
}

export default App;
