import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { ImageModule } from '../image/image.module';

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class UserModule {
  username: string = '';
  email: string = '';
  roles: string[] = [];
  // images: ImageModule[] = [];
}