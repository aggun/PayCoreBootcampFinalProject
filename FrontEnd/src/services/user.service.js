import axios from 'axios';

const API_URL = 'https://localhost:44388/api/nhb/';
const user = JSON.parse(localStorage.getItem('user'));
var token = ""
if (user != null) {
  token = user.accessToken
}
let axiosConfig = {
  headers: {
      'Content-Type': 'application/json;charset=UTF-8',
      'Authorization': `Bearer ${token}`
  }
};

class UserService {

  getDetails() {
    return axios.get(API_URL + 'Home', {
      headers: {
        Accept: "application/json",
        Authorization: `Bearer ${token}`
      }
    });
  }

  AddProduct(ProductName, Descripton, CategoryId, Color, Brand, Price) {
    const newProduct={ProductName, Descripton, CategoryId, Color, Brand, Price};
    return axios.post(API_URL + 'Product', newProduct,  axiosConfig ,{

    });
  }

  AddCategory(CategoryName) {
    const newCategory= {CategoryName}
    return axios.post(API_URL + 'Category',newCategory ,axiosConfig,    {

    });
  }


  getCategories() {
    return axios.get(API_URL + 'Category', {
      headers: {
        Accept: "application/json",
        Authorization: `Bearer ${token}`
      }
    });
  }



  viewReceiveOffer() {
    return axios.get(API_URL + 'Account/MyReceiveOffer', {
      headers: {
        Accept: "application/json",
        Authorization: `Bearer ${token}`
      }
    });
  }


  viewSendOffer() {
    return axios.get(API_URL + 'Account/MySendOffer', {
      headers: {
        Accept: "application/json",
        Authorization: `Bearer ${token}`
      }
    });
  }


  viewOrder() {
    return axios.get(API_URL + 'Order', {
      headers: {
        Accept: "application/json",
        Authorization: `Bearer ${token}`
      }
    });
  }



  getProducts() {
    return axios.get(API_URL + 'Product', {
      headers: {
        Accept: "application/json",
        Authorization: `Bearer ${token}`
      }
    });
  }

}

export default new UserService();
