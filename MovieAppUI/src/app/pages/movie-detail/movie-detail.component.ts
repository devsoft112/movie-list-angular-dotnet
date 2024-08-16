import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from '../../services/movie.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';

import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss'],
  standalone: true,
  imports: [CommonModule, MatButtonModule, MatCardModule, MatIconModule, MatChipsModule],
})
export class MovieDetailComponent implements OnInit {
  movie: any;
  baseURL = environment.baseURL;
  defaultImage = './assets/default.png';

  constructor(private route: ActivatedRoute, private router: Router, private movieService: MovieService) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.movieService.getMovieById(id).subscribe((movie) => {
      this.movie = movie;
    });
  }
  
  getImageSrc(imageUrl: string): string {
    return `${this.baseURL}${imageUrl}`;
  }

  onImageError(event: Event) {
    const imgElement = event.target as HTMLImageElement;
    imgElement.src = this.defaultImage;
  }

  editMovie(movieId: number, event: Event): void {
    event.stopPropagation(); // Prevent card click from triggering
    this.router.navigate(['/edit-movie', movieId]);
  }

  navigateToList(): void {
    this.router.navigate(['/']);
  }
}
