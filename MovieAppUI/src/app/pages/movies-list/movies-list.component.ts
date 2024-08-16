import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import { MovieService } from '../../services/movie.service';
import { ConfirmDialogComponent } from '../../components/confirm-dialog/confirm-dialog.component';
import { MovieCardComponent } from '../../components/movie-card/movie-card.component';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatCardModule,
    MatButtonModule,
    MatPaginatorModule,
    MatDialogModule,
    MatSnackBarModule,
    MovieCardComponent // Import the MovieCardComponent here
  ]
})
export class MoviesListComponent implements OnInit {
  movies: any[] = [];
  defaultImage: string = './assets/default.png';

  pageSize: number = 10;
  pageNumber: number = 1;
  totalMovies: number = 0;

  constructor(private movieService: MovieService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.fetchMovies();
  }

  fetchMovies(): void {
    this.movieService.getMovies(this.pageNumber, this.pageSize).subscribe(data => {
      this.movies = data.items;
      this.totalMovies = data.totalCount;
    });
  }

  onPageChange(event: any): void {
    this.pageNumber = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.fetchMovies();
  }

  deleteMovie(movieId: number): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '250px',
      data: { message: 'Are you sure you want to delete this movie?' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.movieService.deleteMovie(movieId).subscribe(() => {
          this.snackBar.open('Movie deleted successfully!', 'Close', { duration: 3000 });
          this.fetchMovies();  // Refresh the movie list
        }, error => {
          this.snackBar.open('Failed to delete movie.', 'Close', { duration: 3000 });
        });
      }
    });
  }
}
