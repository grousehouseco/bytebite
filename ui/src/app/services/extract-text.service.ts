import { Injectable } from '@angular/core';
import { createWorker } from 'tesseract.js';
import axios, {isCancel, AxiosError, AxiosRequestConfig, AxiosResponse} from 'axios';
import { GroceryItem } from '../models/grocery-item';

@Injectable({
  providedIn: 'root'
})
export class ExtractTextService {
  mockData: any[] = [
    {
      "brandName": "LA COLOMBE",
      "description": "MEDIUM ROAST UNSWEETENED COLOMBIAN COLD BREW COFFEE, UNSWEETENED COLOMBIAN",
      "gtinUpc": "604913002160"
    },
    {
      "brandName": "SIGGI'S",
      "description": "STRAWBERRY & RHUBARB ICELANDIC STYLE CREAM-SKYR STRAINED WHOLE-MILK YOGURT, STRAWBERRY & RHUBARB",
      "gtinUpc": "898248001589"
    },
    {
      "brandName": "SIGGI'S",
      "description": "VANILLA ICELANDIC STYLE CREAM-SKYR STRAINED WHOLE-MILK YOGURT, VANILLA",
      "gtinUpc": "898248001572"
    }
  ]
  fdcUrl: string = 'https://api.nal.usda.gov/fdc/v1/';
  openFfUrl: string = 'https://world.openfoodfacts.org/api/v2/'; //staging env
  fieldsQuery: string = '&fields=code,product_name,product_quantity,product_quantity_unit,categories_hierarchy,image_thumb_url,allergens_hierarchy,brands,serving_quantity,serving_quantity_unit,serving_size'
  constructor() { }

  public async readUpcFromImage(img: string): Promise<string> {
    // const worker = await createWorker('eng');
    // const ret = await worker.recognize(img);
    // await worker.terminate();
    // const pattern: RegExp = new RegExp('\\d{12}', 'g');
    // var part = ret.data.text.matchAll(pattern);
    // var partArr = [];
    // for(let el of part){
    //   partArr.push(el[0])
    // }
    // return partArr.join(',');
    return "604913002160"
  }

  public async getMock(upcs: string[]) : Promise<any[]> {
    return new Promise((resolve)=>{
      resolve(this.mockData);
    });
  }
}
