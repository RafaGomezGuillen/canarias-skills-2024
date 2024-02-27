import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

// JWT / Barer interceptor
import { tokenInterceptor } from './interceptors/token.interceptor';

// Toast animation
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Components
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { CardsComponent } from './components/home-components/cards/cards.component';
import { HeroComponent } from './components/home-components/hero/hero.component';
import { IconBlocksComponent } from './components/home-components/icon-blocks/icon-blocks.component';
import { TestimonialsComponent } from './components/home-components/testimonials/testimonials.component';

// Pages
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { AdminPageComponent } from './pages/admin/admin-page/admin-page.component';
import { UsersComponent } from './pages/admin/users/users.component';
import { AboutComponent } from './pages/company-pages/about/about.component';
import { CareersComponent } from './pages/company-pages/careers/careers.component';
import { HomeComponent } from './pages/home/home.component';
import { UserComponent } from './pages/layouts/user/user.component';
import { NewsroomComponent } from './pages/company-pages/newsroom/newsroom.component';
import { UserAdminComponent } from './pages/layouts/user-admin/user-admin.component';
@NgModule({
  declarations: [
    AppComponent,
    ErrorPageComponent,
    FooterComponent,
    HeaderComponent,
    CardsComponent,
    HeroComponent,
    IconBlocksComponent,
    TestimonialsComponent,
    LoginComponent,
    RegisterComponent,
    AdminPageComponent,
    UsersComponent,
    AboutComponent,
    CareersComponent,
    HomeComponent,
    UserComponent,
    NewsroomComponent,
    UserAdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({ timeOut: 2000 }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: tokenInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
