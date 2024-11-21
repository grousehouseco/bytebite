import { reactive } from 'vue';
import { useAuth0 } from '@auth0/auth0-vue';

export const auth = reactive({
  currentUser: '',
  userAuthenticated: false,
  doLogin(){
    useAuth0().loginWithRedirect();
    this.currentUser = useAuth0().user;
    this.userAuthenticated = useAuth0().isAuthenticated
  },
  doLogout(){
    useAuth0().logout({ logoutParams: { returnTo: window.location.origin } })
    this.currentUser = '';
    this.userAuthenticated = false;
  }
})  