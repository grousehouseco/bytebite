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
    issuerBaseURL: process.env.ISSUERURL
};

const app = express();
const port = process.env.PORT;
const pantryApiUrl = process.env.PANTRYAPIURL;
app.use(express.json());
app.use(express.urlencoded());
app.use(auth(config));
app.get('/', (req, res) => {
    res.send(req.oidc.isAuthenticated() ? 'Logged in' : 'Logged out');
});
app.use("/pantry", proxy(pantryApiUrl));
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