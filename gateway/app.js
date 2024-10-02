import express from "express";
import dotenv from "dotenv";
import { auth } from "express-openid-connect";
import request from "request";
import proxy from "express-http-proxy";

dotenv.config();

const config = {
    authRequired: false,
    auth0Logout: true,
    secret: process.env.SECRET,
    baseURL: process.env.BASEURL,
    clientID: process.env.CLIENTID,
    clientSecret: process.env.CLIENTSECRET,
    issuerBaseURL: process.env.ISSUERURL,
    authorizationParams: {
        response_type: 'code', // This requires you to provide a client secret
        audience: 'https://digital-pantry',
        scope: 'openid profile'
      }
};

const app = express();
const port = process.env.PORT;
const pantryApiUrl = process.env.PANTRYAPIURL;
app.use(express.json());
app.use(express.urlencoded());
app.use(auth(config));

app.get('/', (req, res) => {
    let msg = req.oidc.isAuthenticated() ? 'Logged in' : 'Logged out';
    res.send(msg);
});

app.get('/profile', (req, res) => {
    res.send(JSON.stringify(req.oidc.user));
  });

app.use("/pantry", proxy(pantryApiUrl, {
    proxyReqOptDecorator: function (proxyReqOpts, srcReq) {
      let {token_type, access_token} = srcReq.oidc.accessToken;
      proxyReqOpts.headers = {"Authorization": `${token_type} ${access_token}`};
      return proxyReqOpts;
    }
  }));
app.listen(port, () => {
    console.log("Listening on port "+port)
    request(pantryApiUrl, function(err, res, body) {
        if(err===null){
            console.log("Pantry API healthy");
        }
        else {
            console.log("Pantry API unreachable");
        }
    })
});