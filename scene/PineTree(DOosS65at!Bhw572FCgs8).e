13
889058230280
908793922426541 1761162255468727100
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 1.7911578416824341,
    "Y": -7.2905559539794922
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "908793924011951:1761162255469096500",
  "next_sibling": "908793921444593:1761162255468498300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "908793922681617:1761162255468786500",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "908793922707589:1761162255468792500",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "908793922681617:1761162255468786500",
    "DefaultRenderer": "908793922746633:1761162255468801600",
    "DepletedRenderer": "908793922756781:1761162255468804000"
  }
},
{
  "cid": 5,
  "aoid": "908793922716748:1761162255468794700",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
