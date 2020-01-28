import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { BrowserModule} from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RegisterComponent } from '../register/register.component';

describe('RegisterComponent', () => {
  let comp: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        RegisterComponent
      ],
      imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule
      ]
    }).compileComponents().then(() => {
      fixture = TestBed.createComponent(RegisterComponent);

      comp = fixture.componentInstance; 
    });
  }));


  it(`should set submitted to true`, async(() => {
    comp.onSubmit();
    expect(comp.submitted).toBeTruthy();
  }));

 it(`form should be invalid`, async(() => {
    comp.contactForm.controls['login'].setValue('');
    comp.contactForm.controls['password'].setValue('');
    expect(comp.contactForm.valid).toBeFalsy();
  }));

  it(`form should be valid`, async(() => {
    comp.contactForm.controls['login'].setValue('DefaultLogin');
    comp.contactForm.controls['password'].setValue('DefaultPassword');
    expect(comp.contactForm.valid).toBeTruthy();
  }));
});
