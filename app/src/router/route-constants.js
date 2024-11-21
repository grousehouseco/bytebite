export const BASE = ':id'
export const HOME = 'home'
export const PANTRY = 'pantry'
export const RECIPES = 'recipes'
export const COOK = 'cook'
export const HOUSEHOLD = 'household'
export const PROFILE = BASE
export const SETTINGS = 'settings'
export const PANTRY_MANAGE = 'manage'
export const NOT_FOUND = 'oops'
export const LOGIN = 'login'

export const leftNavItems = [
  {id: "100", text: "Home", icon: "home", path: [BASE,HOME]},
  {id: "200", text: "Pantry", icon: "kitchen", path: [BASE,PANTRY], children: [
      {id: "210", text: "Manage", icon: "inventory", path: [BASE,PANTRY,PANTRY_MANAGE]}
  ]},
  {id: "300", text: "Recipes", icon: "menu_book", path: [BASE,RECIPES]},
  {id: "400", text: "Cook", icon: "skillet", path: [BASE,COOK]},
  {id: "500", text: "Household", icon: "diversity_4", path: [BASE,HOUSEHOLD]}
]

export class RouteHelper{
  constructor(){}
  formatUrl(urlParts){
    return '/'+urlParts.join('/')
  }
  splitUrlToParts(url){
    if(url){
      let p = url.split('/')
      if(p[0].contains('/')){
        p[0] = p[0].replace('/','')
      }
      return p
    }
    else{
      return []
    }
  }
}



export const breadcrumbs = [
  { route: HOME, breadcrumbs: ["Dashboard"] },
  { route: PANTRY, breadcrumbs: ["Pantry"] },
  { route: PANTRY_MANAGE, breadcrumbs: ["Pantry","Add or Remove Groceries"] },
  { route: PROFILE, breadcrumbs: ["Profile"] },
  { route: SETTINGS, breadcrumbs: ["Profile", "Settings"] },
]