export class Comment {

    constructor(
      public commentId: number,
      public description: string,
      public date: Date,
      public userName: string,
      public userId: number,
      public recipeId: number
    ) {  }
  
  }