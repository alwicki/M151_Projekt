import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FavoritesComponent } from './favorites/favorites.component';
import { HomeComponent } from './home/home.component';
import { ModeratorComponent } from './moderator/moderator.component';
import { MyRecipesComponent } from './my-recipes/my-recipes.component';
import { CreateComponent } from './my-recipes/create/create.component';
import { DetailComponent } from './recipes/detail/detail.component';
import { RecipesComponent } from './recipes/recipes.component';
import { StartComponent } from './start/start.component';

const routes: Routes = [
  {path: 'start', component: StartComponent },
  {path: '', component: HomeComponent},
  {path: 'recipes', component: RecipesComponent},
  {path: 'recipes/detail', component: DetailComponent},
  {path: 'favorites', component: FavoritesComponent},
  {path: 'myrecipes', component: MyRecipesComponent},
  {path: 'myrecipes/create', component: CreateComponent},
  {path: 'moderator', component: ModeratorComponent}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
