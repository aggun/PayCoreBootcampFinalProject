import axios from "axios";

const API_URL = "https://localhost:44388/api/nhb/";

class AuthService {
  login(Email, Password) {
    return axios
      .post(API_URL + "Login", {
        Email,
        Password
      })
      .then(response => {
      
        if (response.data.accessToken) {
          localStorage.setItem("user", JSON.stringify(response.data));
          console.log(localStorage.getItem("user"))
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem("user");
  }

  Register(Email, Name,Password) {
    return axios.post(API_URL + "Register", {
  
      Email,
      Password,
      Name
    });
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem('user'));;
  }
}

export default new AuthService();
