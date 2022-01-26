"""
Testing vector mapping on array
"""
extends Node2D


class logger:
	
	static func debug(msg) -> void:
		if OS.is_debug_build():
			print("[DEBUG]: %s" % msg)
	
	static func info(msg) -> void:
		print("[INFO]: %s" % msg)


export(Array) var animations := [0, 0, 0, 0, 0, 0, 0, 0]
onready var deg_step = 360 / len(animations)

var vectors = [
	Vector2.RIGHT, 	Vector2.ONE, 
	Vector2.DOWN, 	Vector2(-1, 1), 
	Vector2.LEFT, 	Vector2(-1, -1), 
	Vector2.UP, 	Vector2(1, -1)
]


func map_vector(vec: Vector2, step: float) -> int:
	logger.debug("Got %s" % vec)
	
	assert(vec != Vector2.ZERO, "Vector can't be equal Vector2.ZERO: (%s)" % vec)
	assert(vec.is_normalized(), "Vector should be normalized: (%s)" % vec)
	
	var rad = vec.angle()
	var deg = round(rad2deg(rad))
	
	if deg < 0:
		"""
		NOTE(g3k1): More verbose variant
		var t = 180 + deg
		deg = 180 + t
		"""
		deg = 2 * 180 + deg
	
	logger.debug("rad(%s) = %s" % [vec, rad])
	logger.debug("rad [%s] -> deg [%s]" % [rad, deg])

	return deg / step


func _ready() -> void:
	for vec in vectors:
		logger.info(map_vector(vec.normalized(), deg_step))
