export class Recipe {

    constructor(
      public title: string,
      public description: string,
      public persons: number,
      public ingredients: any,
      public steps: any,
      public tags: any,
      public user: any
    ) {  }
  
  }