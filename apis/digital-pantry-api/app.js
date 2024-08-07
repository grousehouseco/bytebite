import express from "express";
import dotenv from "dotenv";
import {auth} from "express-oauth2-jwt-bearer";
import { router } from "./router.js";

dotenv.config();

const jwtCheck = auth({
    audience: 'https://digital-pantry',
    issuerBaseURL: 'https://dev-8lmx35fi5xd8ddzi.us.auth0.com/',
    tokenSigningAlg: 'RS256'
  });

const app = express();
const port = process.env.PORT;
app.use(express.json());
app.use(express.urlencoded());
app.use(jwtCheck);
app.use("/", router);

app.listen(port, () => {
    console.log("Listening on port "+port)
});