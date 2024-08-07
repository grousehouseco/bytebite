class PantryController {
    getFood(req, res){
        return res.send("food getted")
    }
    addFood(req, res) {
        return res.send("added")
    }
    updateFood(req, res) {
        return res.send("updated")
    }
    deleteFood(req, res) {
        return res.send("deleted")
    }
}
export default PantryController;