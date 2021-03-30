import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtractComponent } from './subtract.component';

describe('SubtractComponent', () => {
  let component: SubtractComponent;
  let fixture: ComponentFixture<SubtractComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubtractComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubtractComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });

  //Positive Test Cases
  it('should perform correct subtraction',()=>{
    const fixture = TestBed.createComponent(SubtractComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.subtraction(10,5)).toEqual(5);
  });

  //Negative Test Cases
  it('should perform incorrect subtraction',()=>{
    const fixture = TestBed.createComponent(SubtractComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.subtraction(10,5)).not.toEqual(8);
  })
});
