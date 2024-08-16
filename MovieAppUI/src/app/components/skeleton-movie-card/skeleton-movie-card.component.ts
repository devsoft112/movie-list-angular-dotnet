import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-skeleton-movie-card',
  templateUrl: './skeleton-movie-card.component.html',
  styleUrls: ['./skeleton-movie-card.component.scss'],
  standalone: true,
  imports: [CommonModule, MatCardModule]
})
export class SkeletonMovieCardComponent { }
