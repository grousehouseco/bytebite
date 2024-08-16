export class GroceryItem {
  code: string = '';
  product_name: string = '';
  product_quantity: number = 0;
  product_quantity_unit: string = 'g';
  categories_hierarchy: string[] = [];
  image_thumb_url: string = '';
  allergens_hierarchy: string[] = [];
  brands: string = '';
  serving_quantity: string = '';
  serving_quantity_unit: string = '';
  serving_size: string = '';
}