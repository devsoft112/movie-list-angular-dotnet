import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';

import { MovieService } from '../../services/movie.service';

@Component({
  selector: 'app-create-movie',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatInputModule, MatSelectModule, MatButtonModule, MatIconModule],
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.scss']
})
export class CreateMovieComponent implements OnInit {
  movieForm: FormGroup;
  genres: string[] = ['Action', 'Drama', 'Comedy', 'Sci-Fi', 'Romance', 'Thriller', 'Horror', 'Animation', 'Adventure', 'Fantasy'];
  coverImagePreview: string | ArrayBuffer | null = null;
  isEditMode = false;
  movieId: number | null = null;
  isDragOver = false; // New property to track drag state
  removeImageFlag = false; 

  @ViewChild('fileInput', { static: false }) fileInput!: ElementRef<HTMLInputElement>;

  constructor(
    private fb: FormBuilder,
    private movieService: MovieService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.movieForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      genre: [[], Validators.required],
      coverImage: [null]
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      console.log(params);
      this.movieId = +params.get('id')!;
      this.isEditMode = !!this.movieId;

      if (this.isEditMode) {
        this.loadMovieDetails(this.movieId);
      }
    });
  }

  loadMovieDetails(id: number): void {
    this.movieService.getMovieById(id).subscribe(movie => {
      console.log('movie', movie);
      this.movieForm.patchValue({
        title: movie.title,
        description: movie.description,
        genre: movie.genre,
      });
      this.coverImagePreview = movie.coverImage;
    });
  }

  onCoverImageChange(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      this.movieForm.patchValue({ coverImage: file });
      const reader = new FileReader();
      reader.onload = () => {
        this.coverImagePreview = reader.result;
      };
      reader.readAsDataURL(file);
      this.removeImageFlag = false;
    }
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    this.isDragOver = true;
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    this.isDragOver = false;
  }

  onDrop(event: DragEvent): void {
    event.preventDefault();
    this.isDragOver = false;

    const file = event.dataTransfer?.files[0];
    if (file) {
      this.movieForm.patchValue({ coverImage: file });
      const reader = new FileReader();
      reader.onload = () => {
        this.coverImagePreview = reader.result;
      };
      reader.readAsDataURL(file);
      this.removeImageFlag = false;
    }
  }

  triggerFileInput(): void {
    console.log('hellowrld')
    if (this.fileInput) {
      console.log('hello wr---df')
      this.fileInput.nativeElement.click();
    }
  }

  removeImage(event: Event): void {
    event.preventDefault();
    event.stopPropagation(); 
    console.log('removeImage');
    this.coverImagePreview = null;
    this.movieForm.patchValue({ coverImage: null });
    this.removeImageFlag = true;
  }

  submitForm(): void {
    if (this.movieForm.valid) {
      const formData = new FormData();

      if (this.isEditMode && this.movieId !== null) {
        formData.append('id', this.movieId.toString());
      }

      formData.append('title', this.movieForm.get('title')?.value);
      formData.append('description', this.movieForm.get('description')?.value);

      const genreString = this.movieForm.get('genre')?.value.join(',');
      formData.append('genre', genreString);

      const coverImage = this.movieForm.get('coverImage')?.value;
      if (coverImage) {
        formData.append('coverImage', coverImage);
      } else if (this.removeImageFlag) {
        console.log('image removed');
        formData.append('coverImage', ''); // Send an empty string or handle as per your backend logic
      }

      if (this.isEditMode && this.movieId !== null) {
        this.movieService.updateMovie(this.movieId, formData).subscribe(response => {
          this.snackBar.open('Movie updated successfully!', 'Close', { duration: 3000 });
          this.router.navigate(['/']);  // Navigate back to the list
        }, error => {
          this.snackBar.open('Failed to update movie.', 'Close', { duration: 3000 });
        });
      } else {
        this.movieService.createMovie(formData).subscribe(response => {
          this.snackBar.open('Movie created successfully!', 'Close', { duration: 3000 });
          this.router.navigate(['/']);  // Navigate back to the list
        }, error => {
          this.snackBar.open('Failed to create movie.', 'Close', { duration: 3000 });
        });
      }
    }
  }
}
