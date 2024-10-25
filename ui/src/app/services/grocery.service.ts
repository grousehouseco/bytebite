import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { GroceryItem } from '../models/grocery-item';

@Injectable({
  providedIn: 'root'
})
export class GroceryService {

  constructor() { }
  public async getGroceriesData(upcs: string[]): Promise<GroceryItem[]> {
    var tempArr: GroceryItem[] = [];

    upcs.forEach((upc)=>{
      this.getGroceryData(upc).then(grocRes => {
        if(grocRes !== undefined && grocRes.data.totalHits >= 1){
          const foodData = grocRes.data as GroceryItem;
          tempArr.push(foodData)   
        }
      });
    })
    return tempArr;
  }
  async getGroceryData(upcs: string): Promise<AxiosResponse> {
    //const url = `${this.openFfUrl}search?code=${upcs}${this.fieldsQuery}`
    const url = `http://localhost:5000/groceries?code=${upcs}`
    var resp = axios.get(url)
    console.log(resp)
    return resp
  }
}
