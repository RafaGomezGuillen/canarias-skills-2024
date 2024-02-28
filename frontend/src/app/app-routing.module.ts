import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Guards
import { AuthGuard } from './guards/auth.guard';

// Pages
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { HomeComponent } from './pages/home/home.component';
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { AdminPageComponent } from './pages/admin/admin-page/admin-page.component';
import { UsersComponent } from './pages/admin/users/users.component';
import { UserComponent } from './pages/layouts/user/user.component';
import { AboutComponent } from './pages/company-pages/about/about.component';
import { CareersComponent } from './pages/company-pages/careers/careers.component';
import { NewsroomComponent } from './pages/company-pages/newsroom/newsroom.component';
import { UserAdminComponent } from './pages/layouts/user-admin/user-admin.component';
import { SalaListComponent } from './pages/sala/sala-list/sala-list.component';
import { SalaDetailsComponent } from './pages/sala/sala-details/sala-details.component';
import { ReservaListComponent } from './pages/reserva/reserva-list/reserva-list.component';
// canActivate: [AuthGuard] requires to login

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'salas', component: SalaListComponent },
  { path: 'sala/:id', component: SalaDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'about', component: AboutComponent, canActivate: [AuthGuard] },
  { path: 'careers', component: CareersComponent, canActivate: [AuthGuard] },
  { path: 'newsroom', component: NewsroomComponent, canActivate: [AuthGuard] },
  { path: 'eventos', component: ReservaListComponent, canActivate: [AuthGuard] },
  {
    path: 'profile/:username',
    component: UserComponent,
    canActivate: [AuthGuard],
  },
  // Admin pages
  {
    path: 'admin/admin-page',
    component: AdminPageComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'admin/users',
    component: UsersComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'admin/user/:username',
    component: UserAdminComponent,
    canActivate: [AuthGuard],
  },
  // Error page
  { path: 'not-found', component: ErrorPageComponent },
  { path: '**', redirectTo: 'not-found' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
