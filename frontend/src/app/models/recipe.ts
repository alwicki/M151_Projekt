export class Recipe {

    constructor(
      public recipeId: number,
      public title: string,
      public description: string,
      public persons: number,
      public image: any,
      public ingredients: any,
      public steps: any,
      public tags: any,
      public comments: any,
      public user: any
    ) {  }
  
  }