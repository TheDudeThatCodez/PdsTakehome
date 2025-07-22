build:
	docker-compose build

run:
	docker-compose run --rm pds-takehome

rebuild:
	docker-compose run --build --rm pds-takehome
