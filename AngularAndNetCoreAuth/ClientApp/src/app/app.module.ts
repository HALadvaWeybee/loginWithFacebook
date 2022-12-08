import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
// import { NgxLoadingModule, ngxLoadingAnimationTypes } from 'ngx-loading';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';



import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';
import { FacebookLoginProvider } from 'angularx-social-login';

let config = new AuthServiceConfig([
  {
    autoLogin:false,
    id: FacebookLoginProvider.PROVIDER_ID,
        //Use your FaceBook App Id here
    provider: new FacebookLoginProvider("1133439733973767"),
  },
]);


export function provideConfig() {
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ///Import SocialLoginModule
    SocialLoginModule.initialize(config),
    ///This isn't necessary. It's a just loader that I like :).
    // NgxLoadingModule.forRoot({
    //   animationType: ngxLoadingAnimationTypes.circle,
    //   backdropBackgroundColour: 'rgba(192,192,192,0.4)',
    //   backdropBorderRadius: '4px',
    //   primaryColour: '#64b2cd',
    //   secondaryColour: '#ffffff',
    //   tertiaryColour: '#ffffff'
    // }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ])
  ],
  
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }