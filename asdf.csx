import mojo

Global winPoint:Int = 0 '' 승리 카운트'
Global lifeCount:Int = 5

Class human Extends App

	Field human:myObject 'create class for store variable
	Field bullet:myObject 'create class for store variable
	Field background:Image
	Field life:Image
	Field gameWin:Image
	Field gameOver:Image
	
	
	'' 유닛들
	'''' 새
	Field bird1:unit
	Field bird2:unit
	Field bird3:unit
	'''' 몬스터
	Field monster:unit
	Field monster2:unit

	Method OnCreate()
		SetUpdateRate 30 
		gameOver = LoadImage("black.png")
		life = LoadImage ("life.png")
		background = LoadImage ( "background.png" )
		gameWin= LoadImage("gameWin.png")
		
		human = New myObject 
		human.mainImage = LoadImage("player.png") 
		
		human.mainImage.SetHandle(0, human.mainImage.Height / 2)
		
		human.x = 10
		human.y = 430
		
		bullet = New myObject 
		bullet.mainImage = LoadImage("bullet.png") 
		bullet.mainImage.SetHandle(bullet.mainImage.Width / 2, bullet.mainImage.Height / 2)
		bullet.x = 0
		bullet.y = 460
		bullet.visible = False 
		
		Local time = Millisecs()
		Local temp = Int(Rnd(time+200))	
		Print temp
		
		
		bird1 = New unit
        bird1.mainImage = LoadImage("bird.png")
        bird1.mainImage.SetHandle(0, bird1.mainImage.Height / 2)
        bird1.x = 600
        bird1.y = 200
        bird1.visible = True
 
        bird2 = New unit
        bird2.mainImage = LoadImage("bird2.png")
        bird2.mainImage.SetHandle(0, bird2.mainImage.Height / 2)
        bird2.x = 900
        bird2.y = 220
        bird2.visible = True
        
        bird3 = New unit
        bird3.mainImage = LoadImage("bird3.png")
        bird3.mainImage.SetHandle(0, bird3.mainImage.Height / 2)
        bird3.x = 800
        bird3.y = 234
        bird3.visible = True
        
        monster = New unit
        monster.mainImage = LoadImage("gob1.png")
        monster.mainImage.SetHandle(0, monster.mainImage.Height / 2)
        monster.x = 700
        monster.y = 430
        monster.visible = True
        
        monster2 = New unit
        monster2.mainImage = LoadImage("gob2.png")
        monster2.mainImage.SetHandle(0, monster2.mainImage.Height / 2)
        monster2.x = 1000
        monster2.y = 425
        monster2.visible = True

	End
	
	Method OnUpdate()
	
	Print winPoint

		Local dx:Float = MouseX() -human.x; '목표 x 좌표
		Local dy:Float = MouseY() -human.y; '목표 y 좌표
		Local cursorAngle:Float = ATan2(dy, dx);
		human.rotation = -cursorAngle;
	
		bird1.visible = True
		bird2.visible = True
		bird3.visible = True	
		monster.visible = True			
		monster2.visible = True	
			
		If Not bullet.visible Then

	
			If MouseHit() Then	
				Print "hitted"

				Local cos:Float = Cos(-human.rotation)
				Local sin:Float = Sin(-human.rotation)
				Local speed:Float = 20
				
				bullet.x = human.x + cos * 100
				bullet.y = human.y + sin * 100
				bullet.vx = cos * speed
				bullet.vy = sin * speed
				bullet.visible = True
			Endif
		Else
			bullet.vy += 0.7
			'총알 회전
			Local radians:Float = ATan2(bullet.vy, bullet.vx)
			bullet.rotation = -radians
			
			'총알의 움직임
			bullet.x += bullet.vx
			bullet.y += bullet.vy
			
		' 총알이 사라질 조건
		
			If (bullet.y >= DeviceHeight()) Or (bullet.x >= DeviceWidth()) Then
				bullet.visible = False
			Endif
			'' 타격 효과 범위 줄이기
				If (bullet.x > bird1.x - 15) And (bullet.x < bird1.x + 30) Then 
		            If (bullet.y > bird1.y - 10) And (bullet.y < bird1.y + 15) Then
			            bird1.visible = False
			 			bird1.x = 1000
			 			winPoint += 1
		 			
			 			
		         Endif 
		      Endif
		    
		      If (bullet.x > bird2.x - 15) And (bullet.x < bird2.x + 15) Then 
		            If (bullet.y > bird2.y - 15) And (bullet.y < bird2.y + 15) Then
			            bird2.visible = False
			 			bird2.x = 1000
			 			winPoint += 1
		 			
		         Endif 
		      Endif
		      

		      If (bullet.x > bird3.x - 15) And (bullet.x < bird3.x + 15) Then 
		            If (bullet.y > bird3.y - 15) And (bullet.y < bird3.y + 15) Then
			            bird3.visible = False
			 			bird3.x = 1000
			 			winPoint += 1
		 	
		         Endif 
		      Endif
		      If (bullet.x > monster.x - 15) And (bullet.x < monster.x + 15) Then 
		            If (bullet.y > monster.y - 15) And (bullet.y < monster.y + 15) Then
			            monster.visible = False
			 			monster.x = 1000
			 			winPoint += 1
		 			
			 			
		         Endif 
		      Endif
		      
		      If (bullet.x > monster2.x - 15) And (bullet.x < monster2.x + 15) Then 
		            If (bullet.y > monster2.y - 15) And (bullet.y < monster2.y + 15) Then
			            monster2.visible = False
			 			monster2.x = 1000
			 			winPoint += 1
		 			
		         Endif 
		      Endif

		      
		Endif
		
		' 새의 속도
		 bird1.x -= 2
		 

		 bird2.x -= 2.5	
		 bird3.x -= 3
		 
		 monster.x -= 1.5
		 monster2.x -= 1.7		 	 
 
		 '' 생명력 닳을 조건
		 If(bird1.x = 10) Then
				lifeCount -= 1
				bird1.x = 600
		 Endif

		 If(bird2.x = 10) Then
				lifeCount -= 1
				bird2.x = 700
		 Endif
		 
		 	If(bird3.x = 10) Then
			lifeCount -= 1
			bird3.x = 630
		 Endif
		 
		 If(monster.x = 10) Then
				lifeCount -= 1
				monster.x = 666
		 Endif
		 
		 If(monster2.x = 10) Then
				lifeCount -= 1
				monster2.x = 720
		 Endif

			
		
	End Method
	
	
	Method OnRender()
		Cls

		DrawImageRect ( background, 0,0,0,0,640,480)
		
		Select lifeCount
		
					' 생명력 카운트에 따른 하트 변화									
			Case 5
				DrawImageRect (	life, 20,20,0,0,35,35)
				DrawImageRect (	life, 60,20,0,0,35,35)
				DrawImageRect (	life, 100,20,0,0,35,35)
				DrawImageRect (	life, 140,20,0,0,35,35)
				DrawImageRect (	life, 180,20,0,0,35,35)
			
			Case 4
				DrawImageRect (	life, 20,20,0,0,35,35)
				DrawImageRect (	life, 60,20,0,0,35,35)
				DrawImageRect (	life, 100,20,0,0,35,35)
				DrawImageRect (	life, 140,20,0,0,35,35)
			Case 3
				DrawImageRect (	life, 20,20,0,0,35,35)
				DrawImageRect (	life, 60,20,0,0,35,35)
				DrawImageRect (	life, 100,20,0,0,35,35)
				
			Case 2
				DrawImageRect (	life, 20,20,0,0,35,35)
				DrawImageRect (	life, 60,20,0,0,35,35)
				
			Case 1
				DrawImageRect (	life, 20,20,0,0,35,35)
			
			Case 0
				bird1.visible = False
				bird1.x = 0

				bird2.visible = False
				bird3.visible = False
				monster.visible = False
				monster2.visible = False

				bird2.x = 0
				bird3.x = 0
				monster.x = 0
				monster2.x = 0

				
				
				DrawImageRect (	gameOver, 0,0,0,0,640,480)
		End Select 
		
		

		If(winPoint>=15) Then
		
													
			
			bird1.x = 0
			
			bird2.x = 0
			bird3.x = 0
			monster.x = 0
			monster2.x = 0
			
			bird1.visible = False
			bird2.visible = False
			bird3.visible = False
			monster.visible = False
			monster2.visible = False

			DrawImageRect (	gameWin, 0,0,0,0,640,480)
			
			
		Endif

		DrawText(winPoint, 100,100,201,201)
		
		bullet.Draw()
		human.Draw()
		bird1.Draw()

		bird2.Draw()
		bird3.Draw()
		monster.Draw()
		monster2.Draw()

		
	End
End

Class myObject
	Field mainImage:Image
	Field x:Float, y:Float, rotation:Float, vx:Float, vy:Float
	Field alpha:Float = 1
	Field scaleX:Float = .45
	Field scaleY:Float = .45
	Field visible:Bool = True
	
	Method Draw:Void()
		If Not visible Then Return
		SetAlpha alpha
		DrawImage(mainImage, x, y, rotation, scaleX, scaleY)
		SetAlpha 1
	End
End

Class unit Extends myObject
	
End

Function Main()
	
	New human
End

