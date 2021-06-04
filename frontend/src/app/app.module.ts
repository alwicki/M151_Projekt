import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { StartComponent } from './start/start.component';
import { RecipesComponent } from './recipes/recipes.component';
import { DetailComponent } from './recipes/detail/detail.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { MyRecipesComponent } from './my-recipes/my-recipes.component';
import { CreateComponent } from './myRecipes/create/create.component';
import { ModeratorComponent } from './moderator/moderator.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StartComponent,
    RecipesComponent,
    DetailComponent,
    FavoritesComponent,
    MyRecipesComponent,
    CreateComponent,
    ModeratorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
