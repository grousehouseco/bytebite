import { ref } from "vue";
import axios from "axios";

export class UserService {
  userId = ref('')
  userData = ref({})
  constructor(){}
   async getUser(email){
    if(this.userData.value.id) return this.userData
    const url = 'http://localhost:5000/users?pageCount=2&pageSize=10&propertyName=email&propertyValue='+email.replace('@','%40')
    return axios.get(url).then(res =>
      {
        if(res.status !== 200 || res.data.length <= 0){
          axios.post('http://localhost:5000/users', {
            "email": email
          }).then(res => {
            if(res.status === 200)
              this.userData.value = res.data
              return res.data
          })
        }
        else{
          this.userData.value = res.data
          return res.data
        }
      })
    }
}