import { Routes } from '@angular/router';
import { MoviesListComponent } from './pages/movies-list/movies-list.component';
import { CreateMovieComponent } from './pages/create-movie/create-movie.component';
import { MovieDetailComponent } from './pages/movie-detail/movie-detail.component';

export const routes: Routes = [
    { path: '', component: MoviesListComponent },
    { path: 'create-movie', component: CreateMovieComponent },
    { path: 'edit-movie/:id', component: CreateMovieComponent },
    { path: 'details-movie/:id', component: MovieDetailComponent }
];
