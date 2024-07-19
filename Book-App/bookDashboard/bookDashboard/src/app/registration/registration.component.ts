import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiListService } from '../api-list.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  registerForm!: FormGroup;
  profilePicError: string | null = null;

  constructor(private fb: FormBuilder, private router: Router, private apiListService: ApiListService) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, this.passwordMatchValidator]],
      profilePic: [null, Validators.required]
    });
  }

  get username() { return this.registerForm.get('username'); }
  get email() { return this.registerForm.get('email'); }
  get password() { return this.registerForm.get('password'); }
  get confirmPassword() { return this.registerForm.get('confirmPassword'); }

  passwordMatchValidator(control: any) {
    const password = control.root.get('password');
    return password && control.value !== password.value ? { isMatching: true } : null;
  }

  onFileChange(event: any): void {
    const file = event.target.files[0];
    if (file && (file.type === 'image/jpeg' || file.type === 'image/jpg' || file.type === 'image/png')) {
      this.registerForm.patchValue({
        profilePic: file
      });
      this.profilePicError = null;
    } else {
      this.profilePicError = 'Only .jpg, .jpeg, and .png files are allowed.';
      this.registerForm.patchValue({
        profilePic: null
      });
    }
  }

  signup(): void {
    if (this.registerForm.valid) {
      const formData = this.registerForm.value;
      const user = {
        username: formData.username,
        email: formData.email,
        password: formData.password
      };

      this.apiListService.register(user).subscribe(
        response => {
          // Handle successful registration
          alert('Sign up successful!');
          this.registerForm.reset();
          this.router.navigate(['/login']);
        },
        error => {
          // Handle registration error
          alert('Sign up failed. Please try again.');
        }
      );
    }
  }
}
