export class Recipe {

    constructor(
      public Title: string,
      public Description: string,
      public Persons: number,
      public ingredients: any,
      public steps: any,
      public tags: any,
      public user: any
    ) {  }
  
  }