import { Injectable } from '@angular/core';
import { createWorker } from 'tesseract.js';
import axios, {isCancel, AxiosError, AxiosRequestConfig, AxiosResponse} from 'axios';
import { GroceryItem } from '../models/grocery-item';

export class ExtractTextService {
  mockData = [
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
  fdcUrl = 'https://api.nal.usda.gov/fdc/v1/';
  openFfUrl = 'https://world.openfoodfacts.org/api/v2/'; //staging env
  fieldsQuery = '&fields=code,product_name,product_quantity,product_quantity_unit,categories_hierarchy,image_thumb_url,allergens_hierarchy,brands,serving_quantity,serving_quantity_unit,serving_size'
  constructor() { }

  readUpcFromImage(img){
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

  getMock(upcs) {
    return new Promise((resolve)=>{
      resolve(this.mockData);
    });
  }
}
