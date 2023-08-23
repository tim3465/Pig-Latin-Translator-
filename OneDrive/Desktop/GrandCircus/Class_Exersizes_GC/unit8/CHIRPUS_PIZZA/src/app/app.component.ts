import { Component } from '@angular/core';
import { MenuItem } from './models/menu-item';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})



export class AppComponent {
  title = 'WELCOME TO CHIRPUS PIZZA';
  OnTheMenu:MenuItem[] = [ 
    {
      Name: "Margherita Pizza",
      Category: "Dinner",
      Price: 12.99,
  },
  {
      Name: "Pepperoni Pizza",
      Category: "Dinner",
      Price: 14.99,
  },
  {
      Name: "Pesto Chicken Pizza",
      Category: "Dinner",
      Price: 15.99,
  },
  
  // Sides
  {
      Name: "Garlic Breadsticks",
      Category: "Sides",
      Price: 4.99,
  },
  {
      Name: "Mozzarella Sticks",
      Category: "Sides",
      Price: 6.99,
  },
  
  // Salads
  {
      Name: "Caesar Salad",
      Category: "Salads",
      Price: 8.99,
  },
  {
      Name: "Caprese Salad",
      Category: "Salads",
      Price: 9.99,
  },
  
  // Desserts
  {
      Name: "Tiramisu",
      Category: "Desserts",
      Price: 7.99,
  },
  {
      Name: "Cannoli",
      Category: "Desserts",
      Price: 5.99,
  },
  ];
  
  getByCategory(cat:string):MenuItem[] {
    let menuCat: MenuItem [] = [];
    this.OnTheMenu.forEach((p:MenuItem) =>{

      if(p.Category==cat)
      {
      menuCat.push(p);
      }
    });
    return menuCat; 
  } 
  GetDistinctCategories():string[] {
    let category:string [] =[];
    this.OnTheMenu.forEach((p:MenuItem) =>{
      if(category.includes(p.Category)==false)
      {
        category.push(p.Category);
      }

    });

    return category;
  }


}
