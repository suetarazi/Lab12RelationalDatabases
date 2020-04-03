# Lab12RelationalDatabases
## Async Hotels

By Sue Tarazi & Brody Rebne

4/1/2020

## Introduction

This app is a hotel room database service built to serve a national hotel chain. It is designed to efficiently track information about each room across many different locations, including layout, amenities, and pricing.

## Structure

[database structure](https://i.imgur.com/qvQPf7A.png)

#### Main Tables:
**Hotel** - different locations across the country.
- 1:N with HotelRoom
**Room** - templates for rooms, including layout and amenities.
- 1:N with HotelRoom
- 1:N with RoomAmenities
**Amenities** - a specific amenity, like a minifridge.
- 1:N with RoomAmenities

#### Join Tables:
**HotelRoom** - specific instances of rooms. This table contains more specific information, like nightly rate. This join provides a N:N relationship between Hotels and Rooms.
**RoomAmenities** - join table for linking amenities to rooms that provide them. This join provides an N:N relationship between Rooms and Amenities.