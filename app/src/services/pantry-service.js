import axios from 'axios';
export class PantryService {

  constructor() { }
  getGroceriesData(upcs) {
    var tempArr = [];

    upcs.forEach((upc)=>{
      this.getGroceryData(upc).then(grocRes => {
        if(grocRes !== undefined && grocRes.data.totalHits >= 1){
          const foodData = grocRes.data;
          tempArr.push(foodData)   
        }
      });
    })
    return tempArr;
  }
  getGroceryData(upcs) {
    //const url = `${this.openFfUrl}search?code=${upcs}${this.fieldsQuery}`
    const url = `http://localhost:5000/groceries?code=${upcs}`
    var resp = axios.get(url)
    console.log(resp)
    return resp
  }
}
