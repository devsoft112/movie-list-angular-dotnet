import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatChipsModule
  ]
})
export class MovieCardComponent {
  @Input() movie: any;
  @Output() delete = new EventEmitter<number>();

  constructor(private router: Router) { }

  getDisplayedGenres(genres: string[]): string[] {
    return genres.slice(0, 2); // Return only the first two genres
  }

  getImageSrc(imageUrl: string): string {
    return imageUrl || './assets/default.png';
  }

  getShortDescription(description: string): string {
    const maxLength = 120; // Maximum characters before truncation
    return description.length > maxLength ? description.slice(0, maxLength) + '...' : description;
  }

  navigateToDetail(movieId: number): void {
    this.router.navigate(['/details-movie', movieId]);
  }

  editMovie(movieId: number, event: Event): void {
    event.stopPropagation(); // Prevent card click from triggering
    this.router.navigate(['/edit-movie', movieId]);
  }

  deleteMovie(movieId: number, event: Event): void {
    event.stopPropagation(); 
    this.delete.emit(movieId);
  }
}
