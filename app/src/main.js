import './assets/main.css'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createAuth0 } from '@auth0/auth0-vue';
import { UserService } from './services/user-service';
import { RouteHelper } from './router/route-constants';

const app = createApp(App)

app.use(router)
app.use(
  createAuth0({
    domain: "dev-8lmx35fi5xd8ddzi.us.auth0.com",
    clientId: "ckR3YQpSaPSusDfwr5bC1DzTI3qxMvnZ",
    authorizationParams: {
      redirect_uri: window.location.origin
    }
  })
);
app.provide('routeHelper', new RouteHelper())
app.provide('userService', new UserService())
app.mount('#app')
