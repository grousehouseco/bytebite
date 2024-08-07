import express from "express";
import PantryController from "./controllers/pantry.controller.js";

const pCtrl = new PantryController();

export const router = express.Router();
router.get("/api/food", pCtrl.getFood);
router.post("/api/food", pCtrl.addFood);
router.put("/api/food", pCtrl.updateFood);
router.delete("/api/food", pCtrl.deleteFood);